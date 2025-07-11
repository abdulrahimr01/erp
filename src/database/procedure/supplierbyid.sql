-- PROCEDURE: public.sp_supplierbyid(character varying, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_supplierbyid(character varying, bigint);

CREATE OR REPLACE PROCEDURE public.sp_supplierbyid(
	IN p_action character varying,
	IN p_id bigint)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
	  -- Get by Id
	  IF p_action = 'Get' THEN
	         SELECT *from supplier
	    	 WHERE id = p_id;
	  END IF;
	  
	  -- Delete
	  IF p_action = 'Delete' THEN
	         DELETE from supplier
	    	 WHERE id = p_id;
	  END IF; 
	  
	  -- Update Active Status
	  IF p_action = 'active' THEN
	         UPDATE supplier set isactive= 1
	    	 WHERE id = p_id;
	  END IF;   
	  
	  -- Update InActive Status
	  IF p_action = 'inactive' THEN
	         UPDATE supplier set isactive= 0
	    	 WHERE id = p_id;
	  END IF;   
	  
END;
$BODY$;
ALTER PROCEDURE public.sp_supplierbyid(character varying, bigint)
    OWNER TO postgres;
