# BOG.Framework
A general collection of utility methods and classes, which has become my Swiss Army knife over the years.
Contains NUnit testing, and a collection of WinForms for demonstration.

The classes are:

### AccessControl:
  A wrapper for the ACL method for folders, to add/remove users and change inheritance.
  
### AssemblyVersion:
  A class which uses reflection to extract the assembly info for an executable or assembly.

### BabbleOn:
  Allows real-time monitoring of a service or other headless operation from any TCP client.
  
### CipherUtility.cs
  A nice static class for encryption from an external source.

### ConsoleControl:
  For console applications: a cleaner way to handle CTRL+BREAK.

### DetailedException:
  Enables formatting of an exception with:
  - Optional header/footer content:
  - One of three level of details for display or logging: User, Machine or Enterprise.
  - Optional masking of user and password, or only password, in URLs and connection strings.
  
### DynamicScripting
  A wrapper for the CodeDom namespace for simple real-time compilation and execution of C#/VB scripts.

### Formatting:
  Common phrase formatting. Currently provides a method of squashing a number into Kilo, Mega, ..., Yota.
  E.g.  (2,325,078 becomes 2.33M).  Also contains a method of writing out a dollar amount into a phrase
  as it would appear on a paper check.

### Fuse:
  Similar to an electrical fuse: records hits(frequency) and volume, and reports when thresholds are exceeded.

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

### SerializableDictionary
  A replacement for the standard Dictionary<K,V> class, which does not allow serialization.
  
### Serializer
  A static class containing methods to serialize and deserialize XML between objects, strings and files.
  
### SettingsDictionary
  A kind of Dictionary<string,object> with internal methods to load, save and merge.  Originally designed
  as a class to store user settings for a desktop application, outside of the app.config architecture.
  
### StringEx
  Some useful string methods, like search and replace with wildcards, currency formatting, filtering (include and exclude), and placeholder replacement.
  
