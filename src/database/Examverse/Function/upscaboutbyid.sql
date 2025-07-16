-- FUNCTION: public.fn_upscaboutbyid(character varying, bigint)

-- DROP FUNCTION IF EXISTS public.fn_upscaboutbyid(character varying, bigint);

CREATE OR REPLACE FUNCTION public.fn_upscaboutbyid(
	p_action character varying,
	p_id bigint)
    RETURNS boolean
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
DECLARE affected_rows INT;
BEGIN
--delete
IF p_action='Delete' THEN
DELETE FROM upscabout WHERE id=p_id;
GET DIAGNOSTICS affected_rows=ROW_COUNT;
RETURN affected_rows>0;
END IF;

--update active status
IF p_action = 'active' THEN
UPDATE upscabout SET isactive=TRUE WHERE id=p_id;
GET DIAGNOSTICS affected_rows=ROW_COUNT;
RETURN affected_rows>0;
END IF;

--update inactive status
IF p_action='inactive' THEN
UPDATE upscabout SET isactive=FALSE WHERE id=p_id;
GET DIAGNOSTICS affected_rows=ROW_COUNT;
RETURN affected_rows>0;
END IF;
RETURN FALSE;
END
$BODY$;

ALTER FUNCTION public.fn_upscaboutbyid(character varying, bigint)
    OWNER TO postgres;
