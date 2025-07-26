-- FUNCTION: public.fn_login(character varying, character varying, character varying, character varying)

-- DROP FUNCTION IF EXISTS public.fn_login(character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION public.fn_login(
	p_action character varying,
	p_username character varying,
	p_password character varying,
	p_newpassword character varying DEFAULT NULL::character varying)
    RETURNS TABLE(id bigint, name character varying, email character varying, mobile character varying, address character varying, roleid bigint, actionby character varying, actiondate timestamp without time zone, isactive boolean, islogin boolean) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    IF p_action = 'login' THEN
        RETURN QUERY
        SELECT u.id, u.name, u.email, u.mobile, u.address,
               u.roleid, u.actionby, u.actiondate, u.isactive, u.islogin
        FROM users u
        WHERE (u.email = p_username OR u.mobile = p_username)
          AND u.password = p_password
          AND u.isactive = true;

    ELSIF p_action = 'password' THEN
        UPDATE users
        SET password = p_newpassword
        WHERE (users.email = p_username OR users.mobile = p_username)
          AND users.password = p_password;

        RETURN QUERY
        SELECT u.id, u.name, u.email, u.mobile, u.address,
               u.roleid, u.actionby, u.actiondate, u.isactive, u.islogin
        FROM users u
        WHERE (u.email = p_username OR u.mobile = p_username)
          AND password = p_newpassword;
    END IF;
END;
$BODY$;

ALTER FUNCTION public.fn_login(character varying, character varying, character varying, character varying)
    OWNER TO postgres;
