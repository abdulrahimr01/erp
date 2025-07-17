-- FUNCTION: public.fn_customerget(character varying, bigint, integer, integer, character varying, character varying)

-- DROP FUNCTION IF EXISTS public.fn_customerget(character varying, bigint, integer, integer, character varying, character varying);

CREATE OR REPLACE FUNCTION public.fn_customerget(
	p_action character varying,
	p_id bigint DEFAULT 0,
	p_skip integer DEFAULT 1,
	p_take integer DEFAULT 10,
	p_ordercol character varying DEFAULT 'id'::character varying,
	p_orderdir character varying DEFAULT 'ASC'::character varying)
    RETURNS TABLE(id bigint, typeid character varying, name character varying, gst character varying, landline character varying, email character varying, contact character varying, mobile character varying, address character varying, actionby character varying, isactive boolean) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE
    sql TEXT;
BEGIN

    -- Get By Id
    IF p_action = 'GETBYID' AND p_id IS NOT NULL THEN
            RETURN QUERY SELECT * FROM customer WHERE id = p_id;
        END IF;

    -- Get All
    IF p_action = 'GETALL' THEN
            RETURN QUERY SELECT * FROM customer;
        END IF;
    
    -- Get Filter
    IF p_action = 'FILTER' THEN
        sql := format(
            'SELECT * FROM customer ORDER BY %I %s LIMIT %s OFFSET %s',
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

ALTER FUNCTION public.fn_customerget(character varying, bigint, integer, integer, character varying, character varying)
    OWNER TO postgres;
