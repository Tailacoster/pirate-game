# Contributing
This file contains relevant information on how to go about contributing to the project.

## Using Unity Hub

#### Launch Unity Hub
After installing, launch Unity Hub. You will want to install Unity 2018.2.18f1, the most recent version of Unity as of the writing of this document, and the version this game is being developed in. Make sure to install build support for Android, iOS, Windows, Mac and Linux, as well as any other things you anticiapte needing.

#### Link With Repository
If you've already cloned the repository, you will need to link it up the game project within to Unity Hub so you can launch the project. This can be done by clicking the "Open" button and navigating to the repository folder. Highlight over the project folder within the repository folder and click the "Select folder" button. It will launch the game project and you will now have quick access to the project when you launch Unity Hub.

## Using GitHub Desktop

#### Launch GitHub Desktop
After installing, there should be a shortcut automatically created on your desktop. After launching, you should be prompted to login to your GitHub account. You can create an account if you don't have one. After linking up your account, you will be able to clone our repository to your machine.

#### Clone Repository
You will need to clone the online, up-to-date information of the repository to your local machine to be able to test and make changes to it. Select the "clone repository" button on the right side of the window. Head over to the home screen of the online repository and select the green button on the top-right side of the screen that says "Clone or download". Copy the URL link in there, and paste it into your GitHub Desktop application to clone the repository.

#### Branches

Branches are an important aspect to how we will collaborate on our project. Essentially, each branch is its own instance of the project. If you make changes on your own branch, it will not affect any other branches of the project but your own. Just as the project you have cloned is a local version of the project that does not change the project in real-time, the branches you access in GitHub Desktop are also local. This means that all changes you make on your branch are not synced up with your online branch until you push to it.

#### GitHub Desktop Workflow

**NOTE:** Before makine any edits or doing any work, **ALWAYS** ensure that you do **NOT** have the master branch selected. Making changes directly on the master branch can mess a lot of things up with the project. Always make sure that your respective branch is chosen when making edits.

The workflow described below is the step-by-step method used to sync up your local repository and branch with the online repository, before and after working on the project.

**1.** If you've merged all your changes from the last time working, ensure that your branch is synced up to the most recent version of the project. If you have local changes that have not yet been merged, do **NOT** do this step. Select your branch in the "Current branch" dropdown bar. Then, select "Branch" from the toolbar at the top and "Update from master" in there. After doing this, your branch will be updated and look just like the master branch.

**2.** Make edits and changes on the project as you desire.

**3.** Commit your changes to your local branch. This is basically a way of saving your changes to your local branch. This is done by writing a description of the commit at the bottom-left and hitting "Commit to *your-branch-name*".

**4.** Update your online branch by pushing your commits. This is done by clicking the button to the right of "Current branch".

**5.** Navigate to the online repository, and create a pull request if ready to merge your changes into the master branch. This is done by navigating to "Pull requests", selecting your branch to merge into the master branch, and writing a description of hte pull request. After one other person has confirmed the pull request, your pull request can be accepted and your changes will be merged into the master branch.

## Code of Conduct

*Insert info here* (TBD)
