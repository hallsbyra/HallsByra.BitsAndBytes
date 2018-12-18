# HallsByra.BitsAndBytes
LINQ-ish bit/byte manipulation in C#

[![Build status](https://ci.appveyor.com/api/projects/status/owfcha8k9xkeak21?svg=true)](https://ci.appveyor.com/project/koffmoff/hallsbyra-bitsandbytes)

## Changelog

## 2.1.0
- Added ```IEnumerable<byte>.ToUInt64()```
- Updated dependencies

## 2.0.1
### Changes
- Removed dependency to GitVersionTask.

## 2.0.0
### Changes
- Migrated to .NET Standard.
- Some API changes, most notably the `IList<byte>` extension methods use byte indeces instead of bit indeces.

## 1.0.0
Initial version