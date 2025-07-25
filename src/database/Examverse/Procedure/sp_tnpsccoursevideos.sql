-- PROCEDURE: public.sp_tnpsccoursevideos(character varying, character varying, character varying, character varying, character varying, timestamp without time zone, boolean, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_tnpsccoursevideos(character varying, character varying, character varying, character varying, character varying, timestamp without time zone, boolean, bigint);

CREATE OR REPLACE PROCEDURE public.sp_tnpsccoursevideos(
	IN p_coursename character varying,
	IN p_title character varying,
	IN p_youtubevideoid character varying,
	IN p_description character varying,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_isactive boolean,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--Insert
IF p_id = 0 THEN
INSERT INTO tnpsccoursevideos(coursename, title, youtubevideoid, description, actionby, actiondate, isactive) 
VALUES (p_coursename, p_title, p_youtubevideoid, p_description, p_actionby, p_actiondate, p_isactive);
END IF;

--update
IF p_id > 0 AND EXISTS (SELECT 1 FROM tnpsccoursevideos WHERE id=p_id) THEN
UPDATE tnpsccoursevideos SET coursename = p_coursename, title = p_title, youtubevideoid = p_youtubevideoid, description = p_description, actionby = p_actionby, actiondate = p_actiondate, isactive = p_isactive 
WHERE id=p_id;
END IF;

END

$BODY$;
ALTER PROCEDURE public.sp_tnpsccoursevideos(character varying, character varying, character varying, character varying, character varying, timestamp without time zone, boolean, bigint)
    OWNER TO postgres;
