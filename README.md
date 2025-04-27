# Fourth task

## Overview
It contains a web api project that exposes three apis for customers and mvc project that consumes them.

The database was already existing => database first apprach was taken. Entities and the EF context is auto generated.
The web api projects follows clean architecture style.
The mvc project returns views which are gettint the data from the Web api project with ajax requests.
Test project is using testcontainers, XUnit and Refit.

## Setup
- use docker compose up from the root dir and then you have to create the database and tables manually with a script (you can find it in the test project).
