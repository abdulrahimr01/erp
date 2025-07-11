-- FUNCTION: public.fn_usersget(character varying, bigint, integer, integer, character varying, character varying)

-- DROP FUNCTION IF EXISTS public.fn_usersget(character varying, bigint, integer, integer, character varying, character varying);

CREATE OR REPLACE FUNCTION public.fn_usersget(
	p_action character varying,
	p_id bigint DEFAULT 0,
	p_skip integer DEFAULT 0,
	p_take integer DEFAULT 10,
	p_ordercol character varying DEFAULT 'id'::character varying,
	p_orderdir character varying DEFAULT 'ASC'::character varying)
    RETURNS TABLE(id bigint, name character varying, email character varying, mobile character varying, address character varying, roleid bigint, actionby character varying, actiondate timestamp without time zone, isactive boolean, islogin boolean, rolename character varying) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE
	sql TEXT;
BEGIN
	-- Get by Id
	IF p_action = 'GETBYID' THEN
        RETURN QUERY
        SELECT u.id, u.name, u.email, u.mobile, u.address, u.roleid, u.actionby, u.actiondate, u.isactive, u.islogin, r.name
        FROM users u join roles r on u.roleid = r.id
        WHERE u.id = p_id;
	END IF;

	-- Get All
	IF p_action = 'GETALL' THEN
        RETURN QUERY
        SELECT u.id, u.name, u.email, u.mobile, u.address, u.roleid, u.actionby, u.actiondate, u.isactive, u.islogin, r.name
        FROM users u join roles r on u.roleid = r.id;
	END IF;

	-- Get Filter
	IF p_action = 'FILTER' THEN
		sql := format(
			'SELECT u.id, u.name, u.email, u.mobile, u.address, u.roleid, u.actionby, u.actiondate, u.isactive, u.islogin, r.name as rolename
             FROM users u
             JOIN roles r ON u.roleid = r.id
             ORDER BY u.%I %s
             LIMIT %s OFFSET %s',
			p_ordercol,
			CASE UPPER(p_orderdir) WHEN 'DESC' THEN 'DESC' ELSE 'ASC' END,
			p_take,
			p_skip
		);
		RETURN QUERY EXECUTE sql;
	END IF;
END;
$BODY$;

ALTER FUNCTION public.fn_usersget(character varying, bigint, integer, integer, character varying, character varying)
    OWNER TO postgres;
