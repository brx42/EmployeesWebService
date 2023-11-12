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
            "\nid serial primary key," +
            "\nname text not null)");

        _queryFactory.Connection.Query(
            "create table if not exists public.department(" +
            "\nid serial primary key," +
            "\nname text not null," +
            "\nphone text," +
            "\ncompany_id int4 references public.company(id))");

        _queryFactory.Connection.Query(
            "create table if not exists public.employee(" +
            "\nid bigserial primary key," +
            "\nname text not null," +
            "\nsurname text not null," +
            "\nphone text not null," +
            "\ndepartment_id int4 references department(id))");
        
        _queryFactory.Connection.Query(
            "create table if not exists public.passport(" +
            "\nid serial primary key," +
            "\ntype text not null," +
            "\nnumber text not null," +
            "employee_id bigserial references employee(id))");
    }
}