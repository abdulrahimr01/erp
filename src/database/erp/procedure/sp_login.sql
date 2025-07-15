-- PROCEDURE: public.sp_login(character varying, character varying, character varying, character varying)

-- DROP PROCEDURE IF EXISTS public.sp_login(character varying, character varying, character varying, character varying);

CREATE OR REPLACE PROCEDURE public.sp_login(
	IN p_action character varying,
	IN p_username character varying,
	IN p_password character varying,
	IN p_newpassword character varying DEFAULT NULL::character varying)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
	  -- Login
	  IF p_action = 'login' THEN
	         SELECT *from users
	    	 WHERE (email == p_username || mobile == p_username) 
			 and password == p_password and isactive==1;
	  END IF;
	  
	  -- Update Paaword
	  IF p_action = 'password' THEN
	         UPDATE users set password = p_newpassword 
	    	 WHERE (email == p_username || mobile == p_username) 
			 and password == p_password;
	  END IF; 
	  
END;
$BODY$;
ALTER PROCEDURE public.sp_login(character varying, character varying, character varying, character varying)
    OWNER TO postgres;
