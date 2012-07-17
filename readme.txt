Expense Sample Application 4.0 AUGUST 2010 Release (for .NET 4.0)
by Serena Yeoh (serena_yeoh@yahoo.com)

LAYERED ARCHITECTURE SAMPLE
http://layersample.codeplex.com/

Last Updated: AUGUST 2010

INTRODUCTION
============

Layered Architecture Sample is designed to demonstrate how to apply various .NET
Technologies such as Windows Presentation Foundation (WPF), Windows Communication
Foundation (WCF), Windows Workflow Foundation (WF), Windows Form, ASP.NET and 
ADO.NET Entity Framework to the Layered Architecture Design Pattern. It is aimed 
at illustrating how code of similar responsibilities can be factored into multiple 
logical layers which are applicable in most of today's enterprise applications.

The primary objective of the sample is to focus on layering and therefore, certain 
cross-cutting functionalities have been omitted to maintain its simplicity.


1. PRE-REQUISITES
=================

1.1 VISUAL STUDIO 2010

    This release of Layered Architecture Sample is not supported on earlier 
    versions of Visual Studio other than Visual Studio 2010.
    
    Visual Studio 2008 SP1 developers should download the January 2009 release of 
    this sample. (for .NET 3.5 SP1)
    http://www.codeplex.com/LayerSample/Release/ProjectReleases.aspx?ReleaseId=22510

    Visual Studio 2008 developers should downlad the November 2008 release of this
    sample. (for .NET 3.5)
    http://www.codeplex.com/LayerSample/Release/ProjectReleases.aspx?ReleaseId=19929
    
    Visual Studio 2005 developers should download the March 2008 release of this
    sample. (for .NET 3.0)
    http://www.codeplex.com/LayerSample/Release/ProjectReleases.aspx?ReleaseId=11916


1.2 CONFIGURING THE WORKFLOW INSTANCE STORE

    This application requires that the Workflow Instance Store is created and 
    properly configured in ONE database named WorkflowInstanceStore.

    If you have chosen different database names, you may configure this application
    to use them via the config files.

    If you have not configured your Workflow Instance Store, please refer to the
    following steps:

    1. Open SQL Server Management Studio and create a new database. 
       i.e. WorkflowInstanceStore

    2. Once the database is created, go to File->Open->File
    
    3. Navigate to the folder 
       %WINDIR%\Microsoft.NET\Framework\v4.xxx\SQL\EN

    4. Open the following two scripts:
       a. SqlWorkflowInstanceStoreSchema.sql
       b. SqlWorkflowInstanceStoreLogic.sql

    5. Ensure that the database i.e. WorkflowInstanceStore, is selected in the 
       database drop down.
 
    6. Execute the script SqlWorkflowInstanceStoreSchema.sql and then followed by 
       SqlWorkflowInstanceStoreLogic.sql


2. SETUP INSTRUCTIONS
=====================

1) Run the script provided in the Database folder to create the sample database.
   Verify you have the ExpenseSample database created after execution.

2) Configure the credentials to your database in the config files of the Host that 
   you have chosen i.e. ConsoleHost

2.1 CONNECTION STRINGS

    Please verify the connection string credentials for the ExpenseSample and 
    WorkflowInstanceStore databases in the .config files for the following projects 
    before running the solution:

	1. App.config in ExpenseSample.Hosts.ConsoleHost project.

	2. App.config in ExpenseSample.Hosts.WindowsServiceHost project.

	3. Web.config in Hosts.WebHost web site.

3) Compile and run the solution.


3. SETTING UP THE WINDOWS SERVICE HOST (OPTIONAL)
=================================================

This sample contains 3 hosts - IIS (or Web), Console and Windows Service. By 
default, the solution launches the ConsoleHost when executed.

To setup the Windows Service Host, follow these steps:

1) Open a Visual Studio Command Prompt and navigate to the 
   ExpenseSample\bin folder.

2) Run installutil ExpenseSample.Hosts.WindowsServiceHost.exe

3) Open the Services MMC Snap-In and Start the service.

WARNING: Only one host can be active at a time. You cannot have more than one host
running at the same time as there will be port conflicts.

To uninstall the Windows Service Host:

1) Open a Visual Studio Command Prompt and navigate to the 
   ExpenseSample\bin folder.
   
2) Run installutil /u ExpenseSample.Hosts.WindowsServiceHost.exe


4. KNOWN ISSUES
===============

1) You may sometimes receive errors for not being able to connect to the host when
   you run the solution. This is due to the clients running ahead before the host is
   fully initialized. Simply click REFRESH on the client to ensure no further errors
   are reported.

2) Workflow Instance Store and ExpenseSample database will go out-of-sync if you
   somehow managed to reset the ExpenseSample database when there are incomplete
   expenses. You will need to manually purge the records in the Workflow Instance
   Store when this happens.


5. MORE INFORMATION ON THE APPLICATION ARCHITECTURE
===================================================

For more information on the Application Architecture, please download the 
Application Architecture Guide V2 from
http://msdn.microsoft.com/en-us/library/dd673617.aspx