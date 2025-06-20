using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Persistence
{
    public class StoredProcedureConfiguration
    {

        public static string MenuWithRolAndApp=@"
            create or alter procedure MenuWithRolAndApp

            @title nvarchar(50)
            as
            begin 
            select 
            m.Id, 
            m.DisplayName,
            m.IconName, 
            m.Route,
            a.Id as IdAplicacion, 
            a.Descripcion as Aplicacion , 
            r.Id as IdRol, 
            r.Name as Rol, 
            m.ParentMenuId,
            m.Status 
            from Administrador.Menu m 
            join MenuRol mr on m.Id=mr.IdMenu 
            join Role r on r.Id=mr.IdRole 
                join Administrador.Aplicacion a on m.IdAplicacion=a.Id
                twhere (m.DisplayName like '%'+@title+'%')
            end;
            go";

        public static string AppWithSede = @"
          create or alter procedure AppWithSede
	            @title nvarchar(50)
            as
            begin 
            select 
	            a.Id, 
	            a.Descripcion,
	            s.Id as IdSede, 
	            s.Descripcion as Sede,
	            a.Status 
	            from Administrador.Aplicacion a 
			            join SedeAplicacion sa on a.Id=sa.IdAplicacion
			            join General.Sede s on s.Id=sa.IdSede
		            where (a.Descripcion like '%'+@title+'%')
            end;
            go";
    }
}
