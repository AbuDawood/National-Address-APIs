This is a C# Wrapper library for the National Address APIs provided by the Saudi Arabia Government.

## Overview

*National-Address-APIs* is fully featured API client library.
Covers all the API features available in the [National Address API](https://api.address.gov.sa/). It is being developed in C# for the Microsoft .NET including .Net Framework v4.6.1+ 
 
 ## Getting Start

 1. Register: (one time per lanch : e.g. in Startup.cs)

call the `Register()` method to assign necessary elements i.e. the base url, API `Key1`, and API `Key2`.

      var baseUrl = "https://apina.address.gov.sa/NationalAddress/"

      var key1 = "#########################";

      var key2 = "##########################";

      SaAddressConfig.Register(baseUrl, key1, key2);

 1. Use:
Use an instance of SaAddressServices() to begin consuming the API services

        var saApiReq = new SaAddressServices();
         respons = await saApiReq.PoiFreeTextAsync("searched-point-of-interest", 1);
         


 ## TODO
 
 - Adding delay request timespan
 - set the classes and methods summary
