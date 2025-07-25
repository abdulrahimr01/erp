-- FUNCTION: public.fn_categorybyid(character varying, bigint)

-- DROP FUNCTION IF EXISTS public.fn_categorybyid(character varying, bigint);

CREATE OR REPLACE FUNCTION public.fn_categorybyid(
	p_action character varying,
	p_id bigint)
    RETURNS boolean
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
DECLARE
    affected_rows INT;
BEGIN
    -- Delete
    IF p_action = 'Delete' THEN
        DELETE FROM category WHERE id = p_id;
        GET DIAGNOSTICS affected_rows = ROW_COUNT;
        RETURN affected_rows > 0;
    END IF;

     -- Update Active Status
	IF p_action = 'active' THEN
        UPDATE category SET isactive = TRUE WHERE id = p_id;
        GET DIAGNOSTICS affected_rows = ROW_COUNT;
        RETURN affected_rows > 0;
    END IF;  
	  
	  -- Update InActive Status
	IF p_action = 'inactive' THEN
        UPDATE category SET isactive = FALSE WHERE id = p_id;
        GET DIAGNOSTICS affected_rows = ROW_COUNT;
        RETURN affected_rows > 0;
    END IF;

    RETURN FALSE;
END;
$BODY$;

ALTER FUNCTION public.fn_categorybyid(character varying, bigint)
    OWNER TO postgres;
