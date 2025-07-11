-- PROCEDURE: public.sp_users(character varying, character varying, character varying, character varying, character varying, bigint, character varying, timestamp without time zone, boolean, boolean, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_users(character varying, character varying, character varying, character varying, character varying, bigint, character varying, timestamp without time zone, boolean, boolean, bigint);

CREATE OR REPLACE PROCEDURE public.sp_users(
	IN p_name character varying,
	IN p_email character varying,
	IN p_mobile character varying,
	IN p_password character varying,
	IN p_address character varying,
	IN p_roleid bigint,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_isactive boolean,
	IN p_islogin boolean,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
 -- Insert
  IF p_id = 0 THEN
    INSERT INTO users(
      name, email, mobile, password, address,
      roleid, actionby, actiondate, isactive, islogin
    )
    VALUES (
      p_name, p_email, p_mobile, p_password, p_address,
      p_roleid, p_actionby, p_actiondate, p_isactive, p_islogin
    );
  END IF;

  -- Update
  IF p_id > 0 AND EXISTS (SELECT 1 FROM users WHERE id = p_id) THEN
    UPDATE users
    SET name = p_name,
        email = p_email,
        mobile = p_mobile,
        password = p_password,
        address = p_address,
        roleid = p_roleid,
        actionby = p_actionby,
        actiondate = p_actiondate,
        isactive = p_isactive,
		islogin = p_islogin
    WHERE id = p_id;
  END IF;
END;
$BODY$;
ALTER PROCEDURE public.sp_users(character varying, character varying, character varying, character varying, character varying, bigint, character varying, timestamp without time zone, boolean, boolean, bigint)
    OWNER TO postgres;
