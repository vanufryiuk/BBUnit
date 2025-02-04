# Skipping test cases

BBUnit has no test cases at the level of code. Instead, you have a handful of
testing abstractions to generate your test cases automatically. So you can't
skip test cases directly, but it's possible to skip test cases affected by
specific testing abstractions.

There're two attributes for doing this: SkipAttribute and SkipForAttribute.

## SkipAttribute

## SkipForAttribute