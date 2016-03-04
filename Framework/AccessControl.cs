using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.AccessControl;
using System.IO;

namespace BOG.Framework
{
    public class AccessControl
    {
        public AccessControl()
        {
        }

        // Adds an ACL entry on the specified directory for the specified account. 
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

        // Removes an ACL entry on the specified directory for the specified account. 
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

        // Removes an ACL entry on the specified directory for the specified account. 
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
