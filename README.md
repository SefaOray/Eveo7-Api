# Eveo7-Api

Backbone of the api.eveo7.com 

How to build and get this runing on local? 
-----------------------------------------
* Download lastest version of this application.
* Open connectionStrings.config.example
* Edit 'DefaulltConnection' connection string and type your own real connection string.
* Rename the file as connectionStrings.config

Application structure
---------------------
* Token auth is managed by Eveo7.Api
* Logic is managed by Eveo7.Services
* Db operations are managed by Eveo7.Data 

Dependencies
-------------
* Dependency injection 	[Autofac](https://autofac.org/)
* Eve Api Client [EveLi](https://github.com/ezet/evelib)
* Orm [Dapper](https://github.com/StackExchange/dapper-dot-net)

# How to contribute? 
Report a bug
------------
If you have found a bug, please report it using [Issues](https://github.com/SefaOray/Eveo7-Api/issues) page

Fix a bug
---------
Bugs are listed in [Issues](https://github.com/SefaOray/Eveo7-Api/issues) page. 

* Fork this repo
* Fix bug
* Write a test showing bug is fixed
* Make you other tests still passing
* Make pull request
* Enjoy!

New features
------------

If you have a new idea about this application, please open a discussion on [Issues](https://github.com/SefaOray/Eveo7-Api/issues) page first.
