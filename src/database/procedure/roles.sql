-- PROCEDURE: public.sp_roles(character varying, character varying, boolean, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_roles(character varying, character varying, boolean, bigint);

CREATE OR REPLACE PROCEDURE public.sp_roles(
	IN p_name character varying,
	IN p_notes character varying,
	IN p_isactive boolean,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
	  -- Insert
	  IF p_id = 0 THEN
	    INSERT INTO roles(name, notes, isactive)
	    VALUES (p_name, p_notes, p_isactive);
	  END IF;
	  
	  -- Update
	  IF p_id > 0 AND EXISTS (SELECT 1 FROM roles WHERE id = p_id) THEN
	    UPDATE roles
	    SET name = p_name,
	        notes = p_notes,
	        isactive = p_isactive
	    WHERE id = p_id;
	  END IF;  
END;
$BODY$;
ALTER PROCEDURE public.sp_roles(character varying, character varying, boolean, bigint)
    OWNER TO postgres;
