***************************************************************
***************************************************************
*  Installation Readme for Time Manangement App version 2.0.
*
*  Refer to the system requirements for the operating systems
*  supported by the Time Manangement App.
*
***************************************************************
***************************************************************

***************************************************************
*  CONTENTS OF THIS DOCUMENT
***************************************************************
*
* This document contains the following sections:
*
* 1.  Overview
* 2.  System Requirements
* 3.  Installing the Software
* 4.  Before running the software
* 5.  Calculations used
* 6.  Errors
*
***************************************************************
* 1.  OVERVIEW
***************************************************************
*
* The Time Manangement App 2.0 is a GUI. This will make it 
* easier for the user. The user will be asked to input their
* Module information as well as dates and credits. 
* All calculations will be performed by the system. The user can 
* also choose to display their minimum study hours and input how 
* many hours they have worked. The remaining study hours will be 
* displayed. Finally when the user is done
* they can choose if they would like the file to be saved onto
* their system for future reference
* The new features added is that you will not have to input 
* your values every time. The system will store all your information
* In version 2.0 you will have to create an account but do not 
* worry your password will be stored in a MD5 format so no one
* will know your password. This application will make use of 
* MS SQL
*
***************************************************************
* 2.  SYSTEM REQUIREMENTS
***************************************************************
*
*1.  The system must be running on one of the following
*    operating systems:
*    
*    - Microsoft Windows Win 10 with .NET 3.1
*    - Macintosh With Visual Studio
*   
*
*2. The following operating systems are not supported:
*
*    Any version of the following Microsoft operating systems:
*    - MS-DOS
*    - Windows 3.1
*    - Windows NT 3.51
*    - Windows 95
*    - Windows 98
*    - Windows NT 4.0
*    - Windows Vista
*    - Windows 8
*
*    Any version of the following operating systems:
*    - Linux
*    
* 3.  The system should contain at least the minimum system 
*    memory required (1GB) by the operating system.
*
* 4. The following additional software is required 
* 
*	Microsoft Visual Studio Community 2019 Version 16.9.4
*       Microsoft.NET Framework Version 4.8.04084 
*
***************************************************************
* 3.  INSTALLING THE SOFTWARE
***************************************************************
*
*
* 1. Open File on Visual Studio
*     - Select [PROG - Task 2]
*     - Select [PROG - Task 2.sln]
*
* 2. Run Code 
*
* OR
*
*	- Clone from GitHub
*
***************************************************************
* 4. BEFORE RUNNING THE SOFTWARE
***************************************************************
* On Line 169 in the mainwindow replace 'C:\\' with the 
* destination in which
* you want to save your software.

***************************************************************
* 5. CALCULATIONS USED
***************************************************************
* The calcultions used will use the number of credits, number 
* of weeks and class hours per week to determine the self study
* hours required per week.
***************************************************************
*6. Errors
***************************************************************
* If the user chooses to save the file, the built in system
* firewall may prevent it from saving.
***************************************************************
