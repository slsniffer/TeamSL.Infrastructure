# Overview
It is simple, well-organized and clean platform to build simple CRUD solutions based on CQRS pattern based on .NET framework.

## Tools
- [Autofac](https://github.com/autofac/Autofac) - good inversion of control container for .NET applications.
- [NHibernate](https://github.com/nhibernate) - one of the most popular ORM framework
- [Fluent.NHibernate](https://github.com/jagregory/fluent-nhibernate) - good configuration framework for NHibernate.
- [log4net](https://logging.apache.org/log4net/) - popular logging framework

## Quick Start
Look at project Example and see how to use this platform for quick start.

## Database Layer
- Lightweight repository pattern with main CRUD operation out of the box.
- Devide read-only and write repositories to split operations.
- No IQueryable outside of the data layer.
- Small and simple query objects for better structure and unit-testing.

## Domain Layer
- Implementation of CQRS pattern.
- Caching for any query requests.
