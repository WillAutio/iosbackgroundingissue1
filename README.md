# iosbackgroundingissue1

This is a copy of 
https://github.com/RobGibbens/XamarinFormsBackgrounding

It is an example of a bug when downloading a file in the background from iOS in Xamarin Forms.
I changed the url of the file to be downloaded as the original one does not seem to exist today.
I also added a couple of WriteLines before and after the following code found in CustomSessionDownloadDelegate:

    bool success = fileManager.Copy(location.Path, targetFileName, out error);


The Copy command above results in the following error:

    Error during the copy: The file “CFNetworkDownload_5HOsEE.tmp” couldn’t be opened because you don’t have permission to view it.
