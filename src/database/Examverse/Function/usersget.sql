-- FUNCTION: public.fn_usersget(character varying, bigint, integer, integer, character varying, character varying)

-- DROP FUNCTION IF EXISTS public.fn_usersget(character varying, bigint, integer, integer, character varying, character varying);

CREATE OR REPLACE FUNCTION public.fn_usersget(
	p_action character varying,
	p_id bigint DEFAULT 0,
	p_skip integer DEFAULT 1,
	p_take integer DEFAULT 10,
	p_ordercol character varying DEFAULT 'id'::character varying,
	p_orderdir character varying DEFAULT 'ASC'::character varying)
    RETURNS TABLE(id bigint, name character varying, email character varying, mobile character varying, password character varying, address character varying, roleid bigint, actionby character varying, actiondate timestamp without time zone, isactive boolean, islogin boolean) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE sql TEXT;
BEGIN
--getbyID
IF p_action='GETBYID' AND p_id IS NOT NULL THEN
RETURN QUERY SELECT * FROM users WHERE id=p_id;
END IF;

--getAll
IF p_action='GETALL' THEN
RETURN QUERY SELECT * FROM users;
END IF;

--GetFilter
IF p_action='FILTER' THEN
sql:=format(
'SELECT * FROM users ORDER BY %I %s LIMIT %s OFFSET %s',
p_ordercol,
CASE UPPER(p_orderdir) WHEN 'DESC' THEN 'DESC' ELSE 'ASC' END,
p_take,
p_skip);
RETURN QUERY EXECUTE sql;
END IF;

RETURN;
END
$BODY$;

ALTER FUNCTION public.fn_usersget(character varying, bigint, integer, integer, character varying, character varying)
    OWNER TO postgres;
