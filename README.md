**This project is deprecated: it only supports .NET Framework 2.x/3.x/4.x, and is no longer maintained.**

**For compatiblity with NET Core and NET Standard, see its replacement project [BOG.SwissArmyKnife](https://github.com/rambotech/BOG.SwissArmyKnife).**

# BOG.Framework
A general collection of utility methods and classes, which has become my Swiss Army knife over the years.
Contains an NUnit 3 testing project, and a hands-on collection of WinForms for demonstration and experimentation.

Develop: [![CI](https://github.com/rambotech/BOG.Framework/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/rambotech/BOG.Framework/actions/workflows/dotnet-desktop.yml)

The classes are:

### AccessControl
  A wrapper for the ACL method for folders, to add/remove users and change inheritance.
  
### AssemblyInfo
  A publicly-available class to extract data from the AssemblyInfo.cs information, incorporated into the assembly.

### AssemblyVersion
  A class which uses reflection to extract the assembly info for an executable or assembly.

### BabbleOn
  Allows real-time monitoring of a service or other headless operation from any telnet client.
  
### CipherUtility
  A class for enciphering / deciphering.  Allows client to override the SymmetricAlgorithm class used for cipher method.

### ConsoleControl
  For console applications: a cleaner way to handle CTRL+BREAK.

### DetailedException
  Enables formatting of an exception with:
  - Optional header/footer content:
  - One of three level of details for display or logging: User, Machine or Enterprise.
  - Optional masking of user and password, or only password, in URLs and connection strings.
  
### DynamicScripting
  A wrapper for the CodeDom namespace for simple real-time compilation and execution of C#/VB code.

### Formatting
  Provides methods for 
  - Squashing a number into Kilo, Mega, ..., Yota (e.g. 2,325,078 becomes 2.33M).
  - Writing out a dollar amount into a phrase as it would appear on a paper check (e.g. FIVE HUNDRED AND 50/100).

### Fuse
  Similar to an electrical fuse: records frequency and/or volume, and reports when thresholds are exceeded.

### Hasher
  Various hashing methods chosen by an enumerator.

### Iteration
  A class used to manage very large and deep argument sets, where the extropolation can result in millions
  or even billions of combinations. Designed to support multi-level nested looping, where the values at each level 
  for an iteration can be derived by passing in a zero-based index--and vice-versa.  Uses the IterationItem class 
  for an iteration level.

### Logger:
  Provides a method of logging to a file, using a timestamped filename and rollover to a new file when 
  either a file size threshold is met, or when the maximum elapsed time has exceeded a threshold.

### Logging:
  A wrapper for event log writing.

### MathEx:
  Holder for derived mathematical methods.
  
### MemoryList
  A List<> type class, which can enforce unique entries (even if an item is removed), and allows the client
  to specify the order in which items are recalled: FIFO, LIFO or random. Ideal for workflow processes,
  which may receive many requests for the same item, but restrict their action to once per item.
  
### NTGroup:
  Wrappers for working with NT Authentication.  Most useful for systems needing to determine access rights
  from NT Groups for an NT user account.
  
### PasswordHash
  A password hashing algorithm encapsulated in a class.  Fairly secure, and not overly complex.
  
### Scrape
  Contains methods for harvesting content with regular expressions.  See the demo form to understand its
  capability.  Also contains classes MemoryItem and MemoryList, which extend the capabilties of the core
  generic List<> class.

### SecureGram
  Creates an encrypted container which can be sent over a TCP/UDP connection between apps.  Supports automatic
  internal compression for large content.

### SerializableDictionary
  A replacement for the standard Dictionary<K,V> class, which does not allow serialization.
  
### SerializerXML
  A static class containing methods to serialize and deserialize XML between objects, strings and files.
  Also contains methods to convert to/from a secure transport container.
  
### SerializerJSON
  A static class containing methods to serialize and deserialize JSON between objects, strings and files.
  Also contains methods to convert to/from a secure transport container.
  
### SettingsDictionary
  A kind of Dictionary<string,object> with internal methods to load, save and merge.  Originally designed
  as a class to store user settings for a desktop application, outside of the app.config architecture.
  
### StringEx
  Some useful string methods:
  - Search and replace with wildcards
  - Currency parsing
  - Hex to/from methods.
  - Filtering (include and exclude)
  - Placeholder replacement for allowing Environment, Common Folders and Custom Dictionary replacement in 
    a path string.

### Url
  A Url parser which is designed to validate listener url's for a HttpListener object, is less restrictive on
  host portions, and can rebuild a URL after parsing it to remove unnecessary URL encoding.
