using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.AccessControl;
using System.IO;

namespace BOG.Framework
{
	/// <summary>
	/// A wrapper class for manipulating ACL lists on files and folders.
	/// </summary>
	public class AccessControl
	{
		/// <summary>
		/// 
		/// </summary>
		public AccessControl()
		{
		}

		/// <summary>
		/// Adds an ACL entry on the specified directory for the specified account. 
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="Account"></param>
		/// <param name="Rights"></param>
		/// <param name="Inheritance"></param>
		/// <param name="Propogation"></param>
		/// <param name="ControlType"></param>
		public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights,
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
		/// Removes an ACL entry on the specified directory for the specified account. 
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="Account"></param>
		/// <param name="Rights"></param>
		/// <param name="ControlType"></param>
		public static void RemoveDirectorySecurity(string FileName, string Account, FileSystemRights Rights,
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
																ControlType));
			// Set the new access settings. 
			dInfo.SetAccessControl(dSecurity);
		}

		/// <summary>
		/// Removes an ACL entry on the specified directory for the specified account. 
		/// </summary>
		/// <param name="FileName"></param>
		public static void RemoveInheritablePermissons(string FileName)
		{
			// Create a new DirectoryInfo object. 
			DirectoryInfo dInfo = new DirectoryInfo(FileName);
			// Get a DirectorySecurity object that represents the  
			// current security settings. 
			DirectorySecurity dSecurity = dInfo.GetAccessControl();
			// Add the FileSystemAccessRule to the security settings. 
			const bool IsProtected = true;
			const bool PreserveInheritance = false;
			dSecurity.SetAccessRuleProtection(IsProtected, PreserveInheritance);
			// Set the new access settings. 
			dInfo.SetAccessControl(dSecurity);
		}
	}
}
