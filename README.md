# GrowlToToast

Implements a Growl Display with a companion program to forward them to Windows 10 Toast notifications.

* Sends Growl titles and messages
* Supports configurable "silent" mode

## Requirements

* Windows 10

This is untested with but will probably not work on Windows 8.

## Installation

Grab the [latest release](https://github.com/Elusive138/GrowlToToast/releases), and extract the ZIP into `%LocalAppData%\Growl\Displays\GrowlToToast` so that `Growler.dll` and the `Toaster` *folder* are both within the `GrowlToToast` folder.

----

Written for [a SuperUser question](http://superuser.com/questions/1039396/how-do-i-get-growl-for-windows-to-use-native-windows-8-10-notifications).

(And a thanks to [@JourneymanGeek](http://superuser.com/users/10165/journeyman-geek) for being my testing guinea pig, and [@Jonno](http://superuser.com/users/536125/jonno) for the original SDK comment suggestion)