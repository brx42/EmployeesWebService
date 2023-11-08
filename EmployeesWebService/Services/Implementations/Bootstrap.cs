using Dapper;
using EmployeesWebService.Repositories.Interfaces;
using EmployeesWebService.Services.Interfaces;
using SqlKata;
using SqlKata.Execution;

namespace EmployeesWebService.Services.Implementations;

public sealed class Bootstrap : IBootstrap
{
    private readonly QueryFactory _queryFactory;

    public Bootstrap(IDbConnectionManager config)
    {
        _queryFactory = config.PostgresQueryFactory;
    }
    
    public void Begin()
    {
        _queryFactory.Connection.Query(
            "create table if not exists public.company(" +
            "\nid int4 primary key," +
            "\nname text not null)");

        _queryFactory.Connection.Query(
            "create table if not exists public.department(" +
            "\nid int4 primary key," +
            "\nname text not null," +
            "\nphone text," +
            "\ncompany_id int4 references public.company(id))");

        _queryFactory.Connection.Query(
            "create table if not exists public.passport(" +
            "\nid int4 primary key," +
            "\ntype text not null," +
            "\nnumber text not null)");

        _queryFactory.Connection.Query(
            "create table if not exists public.employee(" +
            "\nid bigserial primary key," +
            "\nname text not null," +
            "\nsurname text not null," +
            "\nphone text not null," +
            "\npassport_id int4 references passport(id)," +
            "\ndepartment_id int4 references department(id))");
    }
}