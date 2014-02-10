# RndContacts

A simple generator for contacts. It makes use of a pool of real first and last names and combines them arbitrarily.

# Installation
Install via NuGet:
```
install-package Lohmann.RndContatcs



# Usage
```c#

var randomContactGenerator = new RandomContactGenerator();
IEnumerable<RandomContact> randomContacts = randomContactGenerator.GenerateRandomContacts(42);
