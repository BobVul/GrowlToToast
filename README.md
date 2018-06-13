# GrowlToToast

Implements a Growl Display with a companion program to forward them to Windows 10 Toast notifications (Action Center).

* Sends Growl titles and messages
* Supports configurable "silent" mode

## Requirements

* Windows 10

## Installation

1. Grab the [latest release](https://github.com/BobVul/GrowlToToast/releases)
2. Run the MSI installer. This will install the application and create the "GrowlToToast.Toaster" shortcut in your Start Menu. **The Start Menu shortcut must exist**; it is required in order to display notifications as of Windows 10 v1709.
3. Exit Growl if it is running.
4. Run the "GrowlerInstaller" application. You can run this from the shortcut in your Start Menu, under the GrowlToToast folder. This will add the actual plugin to Growl. In most cases, simply installing it under the "Current User" location will be enough.
5. Start Growl and enable the display in the Growl settings.

## Development notes

* CommandLineParser is installed with `Install-Package CommandLineParser -IgnoreDependencies since [it currently pulls in a large number of useless core libraries](https://github.com/commandlineparser/commandline/issues/227).

----

Written for [a SuperUser question](http://superuser.com/questions/1039396/how-do-i-get-growl-for-windows-to-use-native-windows-8-10-notifications).

(And a thanks to [@JourneymanGeek](http://superuser.com/users/10165/journeyman-geek) for being my testing guinea pig, and [@Jonno](http://superuser.com/users/536125/jonno) for the original SDK comment suggestion)
