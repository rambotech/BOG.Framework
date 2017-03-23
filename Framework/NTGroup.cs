using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Security.AccessControl;

namespace BOG.Framework
{
	/// <summary>
	/// A wrapper for user permissions, group memberships and directory permissions.
	/// Originally designed for web apps to determine permissions with NT authentication.
	/// </summary>
	public class NTGroup
	{
		private bool _MachineIsJoinedToDomain = false;

		/// <summary>
		/// True if the machine is part of a domain, or false if it is part of a workgroup.
		/// </summary>
		public bool MachineIsJoinedToDomain
		{
			get { return _MachineIsJoinedToDomain; }
			set { _MachineIsJoinedToDomain = value; }
		}

		/// <summary>
		/// Instantiation
		/// </summary>
		public NTGroup()
		{
			_MachineIsJoinedToDomain = System.Environment.UserDomainName.ToLower() != System.Environment.MachineName.ToLower();
			try
			{
				Domain x = Domain.GetComputerDomain();
				_MachineIsJoinedToDomain = true;
			}
			catch (ActiveDirectoryObjectNotFoundException)
			{
				_MachineIsJoinedToDomain = false;
			}
		}

		/// <summary>
		/// Gets the UserPrincipal object for the specified user.
		/// </summary>
		/// <param name="userName">The username, which can contain a DOMAIN or MACHINENAME prefix</param>
		/// <returns>The UserPrincipal object</returns>
		public UserPrincipal GetUserAccount(string userName)
		{
			// establish domain context, or workgroup context as appropriate.
			string[] parts = userName.Split(new char[] { '\\' }, StringSplitOptions.None);
			string UserDomain = System.Environment.UserDomainName;
			string UserName = parts[0];
			if (parts.Length > 1)
			{
				UserDomain = parts[0] == "." ? System.Environment.MachineName : parts[0];
				UserName = parts[1];
			}

			PrincipalContext TheDomain = null;
			UserPrincipal TheUser = null;
			if (_MachineIsJoinedToDomain)
			{
				TheDomain = new PrincipalContext(ContextType.Domain);
				TheUser = UserPrincipal.FindByIdentity(TheDomain, userName);
			}
			if (TheUser == null)
			{
				TheDomain = new PrincipalContext(ContextType.Machine);
				TheUser = UserPrincipal.FindByIdentity(TheDomain, userName);
			}
			return TheUser;
		}

		/// <summary>
		/// Get a list of groups to which the user belongs.
		/// </summary>
		/// <param name="user">The UserPrincipal object to query</param>
		/// <returns>an array of strings containing the group names to which the user belongs</returns>
		public string[] GetUserGroupMembership(UserPrincipal user)
		{
			List<string> result = new List<string>();

			// if found - grab its groups.  This method works both for local groups in Workgroup mode, and domain
			// groups when joined to a domain.
			// Some groups can be null.. this code traps that and ignores the entry.  Technique from below.
			// http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/b4dee794-7ca7-4d7c-b609-17a87fea2df8/
			if (user != null)
			{
				var groups = user.GetAuthorizationGroups();
				if (groups != null && groups.Count() > 0)
				{
					// iterate over all groups
					int i = 0;
					while (i < groups.Count())
					{
						try
						{
							var p = groups.ElementAt(i);
							// make sure to add only group principals
							if (p != null && p is GroupPrincipal && p.Name != null)
							{
								if (!result.Contains(p.Name.ToUpper()))
									result.Add(p.Name.ToUpper());
							}
						}
						catch { }
						i++;
					}
				}
			}
			return result.ToArray();
		}

		/// <summary>
		/// Adds an ACL entry on the specified directory or file for the specified account. 
		/// </summary>
		/// <param name="FileName">The file or folder on which to apply the ACL change</param>
		/// <param name="Account">The user account to receive the access</param>
		/// <param name="Rights">The permissions to add to the file or folder</param>
		/// <param name="Inheritance">How the file or folder inherits any permissions</param>
		/// <param name="Propogation">Whether any file or folder permissions are propogated to child objects</param>
		/// <param name="ControlType">Whether the ACL change is allowing or denying access.</param>
		public void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights,
												InheritanceFlags Inheritance, PropagationFlags Propogation,
												AccessControlType ControlType)
		{
			// Create a new DirectoryInfo object. 
			DirectoryInfo dInfo = new DirectoryInfo(FileName);
			// Get a DirectorySecurity object that represents the  
			// current security settings. 
			DirectorySecurity dSecurity = dInfo.GetAccessControl();
			// Add the FileSystemAccessRule to the security settings.  
			dSecurity.AddAccessRule(new FileSystemAccessRule(Account,
															 Rights,
															 Inheritance,
															 Propogation,
															 ControlType));
			// Set the new access settings. 
			dInfo.SetAccessControl(dSecurity);
		}

		/// <summary>
		/// Removes an ACL entry from the specified directory or file for the specified account. 
		/// </summary>
		/// <param name="FileName">The file or folder on which to apply the ACL change</param>
		/// <param name="Account">The user account to receive the access</param>
		/// <param name="Rights">The permissions to add to the file or folder</param>
		/// <param name="Inheritance">How the file or folder inherits any permissions</param>
		/// <param name="Propogation">Whether any file or folder permissions are propogated to child objects</param>
		/// <param name="ControlType">Whether the ACL change is allowing or denying access.</param>
		public void RemoveDirectorySecurity(string FileName, string Account, FileSystemRights Rights,
												   InheritanceFlags Inheritance, PropagationFlags Propogation,
												   AccessControlType ControlType)
		{
			// Create a new DirectoryInfo object. 
			DirectoryInfo dInfo = new DirectoryInfo(FileName);
			// Get a DirectorySecurity object that represents the  
			// current security settings. 
			DirectorySecurity dSecurity = dInfo.GetAccessControl();
			// Add the FileSystemAccessRule to the security settings.  
			dSecurity.RemoveAccessRule(new FileSystemAccessRule(Account,
															 Rights,
															 Inheritance,
															 Propogation,
															 ControlType));
			// Set the new access settings. 
			dInfo.SetAccessControl(dSecurity);
		}

		/// <summary>
		/// Compare items in list B, with items in list A.  If any item in list B matches any item in list A, return true.
		/// Primarily designed to test a user's group memberships against a list of qualifying memberships.  E.g.
		/// Bob is a member of Geeks and Leaders.  When compared to the allowed groups of Users and Nerds, it returns false.
		/// Compared to Users and Geeks, it returns true.
		/// </summary>
		/// <param name="baseItems">string array of items</param>
		/// <param name="matchItems">string array of items</param>
		/// <param name="ignoreCase">self-explanatory</param>
		/// <param name="matchAll">when true, all items in list B must have a match in list A, for the result to be true.</param>
		/// <returns>true when the matching criteria are met, or false if not.</returns>
		public bool ItemsWithinList(string[] baseItems, string[] matchItems, bool ignoreCase, bool matchAll)
		{
			bool result = true;

			foreach (string thisItem in matchItems)
			{
				bool thisItemMatches = false;
				foreach (string thisBase in baseItems)
				{
					thisItemMatches = string.Compare(thisItem, thisBase, ignoreCase) == 0;
					if (thisItemMatches)
						break;
				}
				if (thisItemMatches && !matchAll)
				{
					result = true;
					break;  // only needs one item in matchItems to be in baseItems, and we have it.
				}
				result &= thisItemMatches;
			}
			return result;
		}
	}
}
