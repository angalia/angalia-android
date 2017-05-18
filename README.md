#ui-map

Integrating location and directions in mobile apps will usually involve the map view. With the Map View for Crosslight, now you can easily integrate the map view in Crosslight apps for iOS and Android. With full MVVM compatibility, the sample highlights how you can achieve common and advanced scenarios, such as displaying simple and custom markers, showing different directions and routes with bindings to the ViewModel. To learn more about the map view for each platform, see [iOS Map View](http://developer.intersoftsolutions.com/display/crosslight/iOS+Map+View) and [Android Map View](http://developer.intersoftsolutions.com/display/crosslight/Android+Map+View).

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/map.png?version=2&modificationDate=1456976851841&api=v2)

#Supported Platforms

This sample works on the following platforms:

* iOS: iOS 8 and above
* Android: 4.0.3 and above (optimized for 5.0 and above)

This project requires Crosslight 5.0.5000.526 or higher. For more information, see [Crosslight 5.0 Release Notes](http://developer.intersoftsolutions.com/display/crosslight/Crosslight+5.0+Release+Notes).

#Project Structure

* MapSamples.Android.Material: Crosslight Android.Material project, works on phones and tablets.
* MapSamples.Core: Shared Portable Class Library project running Profile78.
* MapSamples.iOS: Crosslight iOS project, works on iPhones and iPad with Storyboard support.

#Features Overview

* Full MVVM compatibility.
* Features use of the map view in simple and advanced scenarios.
* Use simple markers and custom markers to display placemarks on the map.
* Show different directions, such as driving, cycling, public transport and walking routes.
* Show alternate routes on user interaction.

#Features Highlight

This sample demonstrates various Crosslight Map View features, such as:

* Markers
	* Simple Marker
	* Custom Marker
	* Marker Placement
	* Zoom Level
* Directions
	* Default Route
	* Alternative Routes
	* Travel Mode

#Running the Sample

This sample is NuGet-enabled. For more information on restoring NuGet packages, check out this document: [Introduction to Crosslight NuGet Packages](http://developer.intersoftsolutions.com/display/crosslight/Introduction+to+Crosslight+NuGet+Packages#IntroductiontoCrosslightNuGetPackages-RestoringCrosslightPackages).

##Running on Mac
If you run this sample on Mac Xamarin Studio, all you have to do is just open the solution using Xamarin Studio and the NuGet packages will be restored automatically. Simply set one of the platform projects as start-up projects and run.

##Running on Windows
If you run this sample on Windows Visual Studio, right-click on the solution, then choose Restore NuGet packages. Wait until all the NuGet packages are restored, then simply set one of the platform projects as start-up projects and run.

##Running the Android Sample
Please note that you'll most likely need to run this sample on a device for all features to work properly. By default, this sample will not run out of the box. If you try to run this sample on a device, you'll get blank MapViews. 

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/20160217-093348.png?version=1&modificationDate=1455676435856&api=v2)

This is because to use MapView, it requires a release keystore and have your app registered properly to Google Cloud Console. Since this sample is not shipped with a release keystore, you will need to use Google Cloud Console and register your SHA-1 debug.keystore and package name. Here's how to obtain a key for this sample and run this sample properly.

Open up the [Google Cloud Console](https://console.developers.google.com/). Click on **Google Maps Android API** and enable it.

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/Screen%20Shot%202016-02-17%20at%209.35.24%20AM.png?version=1&modificationDate=1455676557228&api=v2)

Once you've enabled the API, go to the **Credentials** tab. Choose **Create Credentials** and select **API key**.

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/Screen%20Shot%202016-02-17%20at%209.38.57%20AM.png?version=1&modificationDate=1455676770268&api=v2)

In the dialog that appears, choose **Android key**.

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/Screen%20Shot%202016-02-17%20at%209.39.56%20AM.png?version=1&modificationDate=1455676832088&api=v2)

Enter the following information:

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/Screen%20Shot%202016-02-17%20at%209.43.30%20AM.png?version=1&modificationDate=1455677027845&api=v2)

**Name**: Anything you like, this is just an identifier for you to manage your keys in the credentials list.
**Package name**: This corresponds to the **package name** specified in the **AndroidManifest.xml** file inside the **MapSamples.Android.Material/Properties** folder.
**SHA-1 certificate fingerprint**: Use [Xamarin's documentation](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/MD5_SHA1/) to find your SHA-1 certificate fingerprint. 

If you're on Mac, you can execute this command in the terminal to get your SHA-1 fingerprint.

`keytool -exportcert -alias androiddebugkey -keystore /Users/nicholaslie/.local/share/Xamarin/Mono\ for\ Android/debug.keystore -list -v`

Just remember to change the **User** name of your Mac. You'll get an output similar to the following.

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/Screen%20Shot%202016-02-17%20at%209.47.31%20AM.png?version=1&modificationDate=1455677257148&api=v2)

Once you've obtained your SHA-1 fingerprint, you can use it to create the API key. 
You should get an API key.

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/Screen%20Shot%202016-02-17%20at%209.52.45%20AM.png?version=1&modificationDate=1455677597185&api=v2)

Note that you can't use this API key on your local machine, since it's different for each machine. Open up **AndroidManifest.xml** inside the **MapSamples.Android.Material/Properties** folder and paste the new key in.

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/Screen%20Shot%202016-02-17%20at%209.54.32%20AM.png?version=1&modificationDate=1455677714547&api=v2)

Now the sample should run properly.

![image](http://developer.intersoftsolutions.com/download/attachments/16191476/20160217-095856.png?version=1&modificationDate=1455677981727&api=v2)


#Relevant Links

* [iOS Map View](http://developer.intersoftsolutions.com/display/crosslight/iOS+Map+View)
* [Android Map View](http://developer.intersoftsolutions.com/display/crosslight/Android+Map+View)


Copyright © Intersoft Solutions.