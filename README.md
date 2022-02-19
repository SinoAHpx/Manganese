# Manganese

A handy extensions library.

## API reference

### StringDetector
Check if a string is valid
#### Methods
- ```IsNullOrEmpty(Boolean)```: Check if a string is empty or whitespace.
	- ```origin(String)```
	- ```considerWhitespace(Boolean)```: Whether if consider whitespaces as empty, default is false
- ```ThrowIfNullOrEmpty(String)```: Check if a string is null or whitespace.
	- ```origin(String)```
	- ```message(String)```
	- ```considerWhitespace(Boolean)```
- ```IsInt32(Boolean)```: Check if a string is valid int.
	- ```origin(String)```
- ```IsInt64(Boolean)```: Check if a string is valid long.
	- ```origin(String)```
- ```IsDouble(Boolean)```: Check if a string is valid double.
	- ```origin(String)```
- ```IsFloat(Boolean)```: Check if a string is valid float.
	- ```origin(String)```
- ```IsDecimal(Boolean)```: Check if a string is valid decimal.
	- ```origin(String)```
- ```ThrowIfNotDouble(Double)```: Throw if a string is not valid double.
	- ```origin(String)```
	- ```message(String)```
- ```ThrowIfNotFloat(Single)```: Throw if a string is not valid float.
	- ```origin(String)```
	- ```message(String)```
- ```ThrowIfNotDecimal(Decimal)```: Throw if a string is not valid decimal.
	- ```origin(String)```
	- ```message(String)```
- ```ThrowIfNotInt32(Int32)```: Throw if a string is not valid int.
	- ```origin(String)```
	- ```message(String)```
- ```ThrowIfNotInt64(Int64)```: Throw if a string is not valid long.
	- ```origin(String)```
	- ```message(String)```
- ```IsValidJson(Boolean)```: Check if a string is valid json.
	- ```origin(String)```
- ```ThrowIfNotValidJson(String)```: Throw if a string is not valid json document.
	- ```origin(String)```
	- ```message(String)```
- ```IsJObject(Boolean)```: Check if a string is valid json object.
	- ```origin(String)```
- ```IsJArray(Boolean)```: Check if a string is valid json array.
	- ```origin(String)```
- ```ThrowIfNotJObject(JObject)```: Throw if a string is not valid json object.
	- ```origin(String)```
	- ```message(String)```
- ```ThrowIfNotJArray(JArray)```: Throw if a string is not valid json array.
	- ```origin(String)```
	- ```message(String)```
- ```IsValidEmail(Boolean)```: Check if a string is valid email address.
	- ```origin(String)```
- ```ThrowIfNotValidEmail(String)```: Throw if a string is not valid email address.
	- ```origin(String)```
	- ```message(String)```
- ```ContainsAnyOf(Boolean)```: "string".Contains() but extend to every single element in sequence
	- ```origin(String)```
	- ```t(IEnumerable`1)```
- ```IsInteger(Boolean)```: Check if a string is an integer
	- ```origin(String)```
### StringManipulator
Handle a string in a more convenient way
#### Methods
- ```FetchJToken(JToken)```: Fetches value from a json with particular path
	- ```json(String)```
	- ```path(String)```
- ```Fetch(String)```: Fetches value from a json with particular path
	- ```json(String)```
	- ```path(String)```
- ```FetchJToken(JToken)```: Fetches value from a json with particular path
	- ```json(JToken)```
	- ```path(String)```
- ```Fetch(String)```: Fetches value from a json with particular path
	- ```json(JToken)```
	- ```path(String)```
- ```DeserializeTo(T)```: Deserialize a string to a JSON object
	- ```value(String)```
	- ```nullValueHandling(NullValueHandling)```
- ```DeserializeTo(T)```: Deserialize a string to a JSON object
	- ```value(String)```
	- ```settings(JsonSerializerSettings)```
- ```ToJObject(JObject)```: Convert a string to JObject. Exception will be occurred if it not.
	- ```s(String)```
- ```ToJArray(JArray)```: Convert a string to JArray. Exception will be occurred if it not.
	- ```s(String)```
- ```ToJsonString(String)```: Serialize a object to JSON string
	- ```t(T)```
	- ```indented(Boolean)```
- ```ToJsonString(String)```: Serialize a object to JSON string
	- ```t(T)```
	- ```settings(JsonSerializerSettings)```
- ```ToInt32(Int32)```: Convert string to int
	- ```s(String)```
- ```ToInt64(Int64)```: Convert string to long
	- ```s(String)```
- ```RemoveInvalidPathChars(String)```: Remove all the invalid characters in a particular string
	- ```s(String)```
- ```RemoveInvalidFileNameChars(String)```: Remove all the invalid characters in a particular string
	- ```s(String)```
- ```CombinePath(String)```: Path.Combine
	- ```s(String)```
	- ```s2(String[])```
- ```JoinToString(String)```: string.Join but is an extension method
	- ```origin(IEnumerable`1)```
	- ```separator(String)```
- ```JoinToString(String)```: string.Join but is an extension method
	- ```origin(IEnumerable`1)```
	- ```separator(String)```
	- ```selector(Func`2)```: specified IEnumerable.Select() selector
- ```Empty(String)```: Empty specified string in a string
	- ```origin(String)```
	- ```toEmpty(String)```
- ```SubstringBetween(String)```: Substring between two string in this specified string
	- ```origin(String)```
	- ```left(String)```
	- ```right(String)```
	- ```last(Boolean)```: Start right string from last index of it
- ```SubstringAfter(String)```: Substring after a string in specified string
	- ```origin(String)```
	- ```left(String)```
	- ```last(Boolean)```: Start from last eligible string
- ```InsertAfter(String)```: Insert a string after specified string
	- ```origin(String)```
	- ```left(String)```
	- ```toInsert(String)```
	- ```each(Boolean)```: Insert after each matched string
	- ```last(Boolean)```: Start from last matched string
- ```InsertBefore(String)```: Insert a string before specified string
	- ```origin(String)```
	- ```right(String)```
	- ```toInsert(String)```
	- ```each(Boolean)```: Insert before each matched string
	- ```last(Boolean)```: Start from last matched string
### ProcessManipulator
Handle Process in a more convenient way
#### Methods
- ```ReadOutputLine(String)```: Read line from standard output if it exist
	- ```process(Process)```
- ```ReadOutputLineAsync(Task`1)```: Read line asynchronously from standard output if it exist
	- ```process(Process)```
### FileInfoManipulator
Handle FileInfo in a more convenient way
#### Methods
- ```WriteAllText```: File.WriteAllText with UTF-8 encoding.
	- ```file(FileInfo)```
	- ```text(String)```
- ```WriteAllBytes```: File.WriteAllBytes
	- ```file(FileInfo)```
	- ```bytes(Byte[])```
- ```WriteAllLine```: File.WriteAllLines with UTF-8 encoding.
	- ```file(FileInfo)```
	- ```lines(IEnumerable`1)```
- ```GetFileName(String)```: An encapsulation of Path.GetFileName
	- ```path(String)```
	- ```withExtensionName(Boolean)```
### ArrayDetector
Methods for checking specified sequence
#### Methods
- ```IsIn(Boolean)```: Check if a object is exist in a sequence
	- ```t(T)```
	- ```array(IEnumerable`1)```
- ```Any(Boolean)```: Check if a sequence has any of target value in
	- ```sequence(IEnumerable`1)```
	- ```target(T)```
### ArrayManipulator
Handle specified sequence in a more convenient way
#### Methods
- ```RemoveIf(IEnumerable`1)```: RemoveAll but return result
	- ```sources(IEnumerable`1)```
	- ```predicate(Func`2)```
- ```Remove(IEnumerable`1)```: RemoveRange but return result
	- ```sources(IEnumerable`1)```
	- ```toRemove(IEnumerable`1)```
- ```Add(IEnumerable`1)```: AddRange but return result
	- ```sources(IEnumerable`1)```
	- ```toAdd(IEnumerable`1)```
- ```Output(IEnumerable`1)```: Output to console
	- ```sources(IEnumerable`1)```
- ```Output(IEnumerable`1)```: Output to console
	- ```sources(IEnumerable`1)```
	- ```manipulator(Func`2)```
- ```Random(TSource)```: Return a random element
	- ```origin(IEnumerable`1)```
