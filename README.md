# References
In this file, we have provided all the references that we have used to implement core functionalities to build this application.
## JWT Token Implementation
http://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api

## Error Handling

https://stackoverflow.com/a/38935583/1273882

https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api

We have done Error Handling in followin way:
1. We always return a certain type of Api Response in case of Error
2. Validation Error (400) - Handled by Action Filter **(Global Handling)**
3. Authorization Error (403) - Handled by Custom Authorization Filter **(Global Handling)**
4. Custom Error Middleware (*) - To handle run time exceptions. **(Global Handling)**
5. Custom implementation of BadRequest() and other such methods to return consistent responses.

## Markdown CheetSheet Guide
https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet

# Angular

## Login and Registration
http://jasonwatmore.com/post/2016/09/29/angular-2-user-registration-and-login-example-tutorial#authentication-service-ts
http://jasonwatmore.com/post/2018/05/16/angular-6-user-registration-and-login-example-tutorial

## Pending
1. Interceptors i.e. To add headers, To handle http-errors
2. Auth Guard i.e. To validate user
