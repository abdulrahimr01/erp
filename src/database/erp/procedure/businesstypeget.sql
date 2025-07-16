-- PROCEDURE: public.sp_businesstypeget(character varying, integer, integer, character varying, character varying)

-- DROP PROCEDURE IF EXISTS public.sp_businesstypeget(character varying, integer, integer, character varying, character varying);

CREATE OR REPLACE PROCEDURE public.sp_businesstypeget(
	IN p_action character varying,
	IN p_skip integer DEFAULT 1,
	IN p_take integer DEFAULT 10,
	IN p_ordercol character varying DEFAULT 'id'::character varying,
	IN p_orderdir character varying DEFAULT 'ASC'::character varying)
LANGUAGE 'plpgsql'
AS $BODY$
	DECLARE  sql TEXT;
BEGIN
	  -- Get All
	  IF p_action = 'Get' THEN
	         SELECT *from businesstype;
	  END IF;
	 
	  -- Get Filter
	  IF p_action = 'Filter' THEN
	    sql := format(
	      'SELECT * FROM businesstype ORDER BY %I %s LIMIT %s OFFSET %s',
	      p_ordercol,
	      CASE UPPER(p_orderdir) WHEN 'DESC' THEN 'DESC' ELSE 'ASC' END,
	      p_take,
	      p_skip
	    );
	    EXECUTE sql;
	  END IF;
END;
$BODY$;
ALTER PROCEDURE public.sp_businesstypeget(character varying, integer, integer, character varying, character varying)
    OWNER TO postgres;
