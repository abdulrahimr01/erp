-- FUNCTION: public.fn_hsnget(character varying, integer, integer, character varying, character varying)

-- DROP FUNCTION IF EXISTS public.fn_hsnget(character varying, integer, integer, character varying, character varying);

CREATE OR REPLACE FUNCTION public.fn_hsnget(
	p_action character varying,
	p_skip integer DEFAULT 1,
	p_take integer DEFAULT 10,
	p_ordercol character varying DEFAULT 'id'::character varying,
	p_orderdir character varying DEFAULT 'ASC'::character varying)
    RETURNS TABLE(id bigint, categoryid character varying, name character varying, notes character varying, gst character varying, sgst character varying, cgst character varying, actionby character varying, isactive boolean) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE
    sql TEXT;
BEGIN

    -- Get By Id
    IF p_action = 'GetById' AND p_id IS NOT NULL THEN
            RETURN QUERY SELECT * FROM hsn WHERE id = p_id;
        END IF;

    -- Get All
    IF p_action = 'Get' THEN
            RETURN QUERY SELECT * FROM hsn;
        END IF;
    
    -- Get Filter
    IF p_action = 'Filter' THEN
        sql := format(
            'SELECT * FROM hsn ORDER BY %I %s LIMIT %s OFFSET %s',
            p_ordercol,
            CASE UPPER(p_orderdir) WHEN 'DESC' THEN 'DESC' ELSE 'ASC' END,
            p_take,
            p_skip
        );
        RETURN QUERY EXECUTE sql;
    END IF;

    RETURN;
END;
$BODY$;

ALTER FUNCTION public.fn_hsnget(character varying, integer, integer, character varying, character varying)
    OWNER TO postgres;
