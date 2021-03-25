# IT_Project

## Contents
* [Overview](#Overview)
* [Installation](#Installation)

## Overview
A website for keeping track of which movies you have watched, your favorite ones and the ones that you plan on watching.

#### Loging in ![login](https://user-images.githubusercontent.com/12987914/112541032-2edf9880-8db3-11eb-833d-37fca1e7816d.gif)

#### My Page ![myPage](https://user-images.githubusercontent.com/12987914/112543824-90edcd00-8db6-11eb-8452-f6fae22ba918.gif)

#### Searching for a movie ![searchForAMovie](https://user-images.githubusercontent.com/12987914/112544020-d1e5e180-8db6-11eb-8bd9-871aefd93ba9.gif)

#### Searching for other users ![searchForOtherUser](https://user-images.githubusercontent.com/12987914/112544301-1f624e80-8db7-11eb-949b-8a9d11e544d9.gif)

## Installation

#### Clone the repository

```bash
$ git clone https://github.com/AleksandarStojanovikj/IT_Project.git
```

Import the project as a Web Site in Visual Studio.

#### Update OMDb API key

Insert your API key in `MovieService.cs`.
```c#
public class MovieService : System.Web.Services.WebService {

    private string omdbAPIkey = "YOUR_API_KEY";

    ...
}

```

#### Setup database

Import the database in the Server Explorer in Visual Studio by right clicking `Data Connections` then selecting `Add Connection`. 
Set `Microsoft SQL Server Database File (SqlClient)` as the data source and select [`Database/pubs/pubs.mdf`](Database/pubs/pubs.mdf) as the database file. Then update the connection string in the `Web.config`. 

```xml
    <add name="myConnection" connectionString="YOUR_CONNECTION_STRING" />

```
The connection string can be found in the database properties in Visual Studio.

#### Setup correct port for the `MovieService`

Make sure to set the correct port of the web site in `Web.config`.

```c#
 <appSettings>
    <add key="webServiceMovieSearch.MovieService" value="http://localhost:CORRECT_PORT/MovieService.asmx"/>
  </appSettings>
  <system.serviceModel>
  ...
    <client>
      <endpoint address="http://localhost:CORRECT_PORT/MovieService.asmx"
       ...
  </system.serviceModel>
  ```

