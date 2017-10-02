# ASP.NET Core - Sync to Async

This is a demo app showing sync versus async calls with ASP.NET Core and Entity Framework Core. It also includes a simple Angular app that consumes the data. You can view a Play-by-Play course about the topic on Pluralsight.com:

https://app.pluralsight.com/library/courses/play-by-play-converting-to-asynch-calls/table-of-contents

## Important Note: 

Is asynchronous code always appropriate? Absolutely not! It can benefit some apps and harm others. This code sample is designed to show synchronous code and how it can be converted to asynchronous code - not to make the determination if async code is appropriate for your app. Every application is different so it's important to do performance testing and evaluate if async code will actually benefit your application. There are situations (such as with long database calls) where it could actually hurt the performance of your app depending on how your thread pools are configured. 

One size NEVER fits all so don't assume that migrating sync code to async will provide a benefit to your app. Put in the time to do the necessary testing.

## Requirements

* ASP.NET Core 1.0 or higher

