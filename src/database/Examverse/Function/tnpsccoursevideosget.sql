-- FUNCTION: public.fn_tnpsccoursevideosget(character varying, bigint, integer, integer, character varying, character varying)

-- DROP FUNCTION IF EXISTS public.fn_tnpsccoursevideosget(character varying, bigint, integer, integer, character varying, character varying);

CREATE OR REPLACE FUNCTION public.fn_tnpsccoursevideosget(
	p_action character varying,
	p_id bigint DEFAULT 0,
	p_skip integer DEFAULT 1,
	p_take integer DEFAULT 10,
	p_ordercol character varying DEFAULT 'id'::character varying,
	p_orderdir character varying DEFAULT 'ASC'::character varying)
    RETURNS TABLE(id bigint, coursename character varying, title character varying, youtubevideoid character varying, description character varying, isactive boolean, actionby character varying, actiondate timestamp without time zone) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE
	sql TEXT;
BEGIN
	-- Get by ID
	IF p_action = 'GETBYID' AND p_id IS NOT NULL THEN
		RETURN QUERY SELECT * FROM tnpsccoursevideos WHERE tnpsccoursevideos.id = p_id;
	END IF;

	-- Get all
	IF p_action = 'GETALL' THEN
		RETURN QUERY SELECT * FROM tnpsccoursevideos;
	END IF;

	-- Filter with pagination and ordering
	IF p_action = 'FILTER' THEN
		sql := format(
			'SELECT * FROM tnpsccoursevideos ORDER BY %I %s LIMIT %s OFFSET %s',
			p_ordercol,
			CASE UPPER(p_orderdir) WHEN 'DESC' THEN 'DESC' ELSE 'ASC' END,
			p_take,
			p_skip
		);
		RETURN QUERY EXECUTE sql;
	END IF;

	RETURN;
END
$BODY$;

ALTER FUNCTION public.fn_tnpsccoursevideosget(character varying, bigint, integer, integer, character varying, character varying)
    OWNER TO postgres;
