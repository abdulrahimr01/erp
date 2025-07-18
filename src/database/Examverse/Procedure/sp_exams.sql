-- PROCEDURE: public.sp_exams(character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_exams(character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_exams(
	IN p_name character varying,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
--insert
IF p_id = 0 THEN
INSERT INTO exams(name,isactive,actionby,actiondate) VALUES(p_name,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM exams WHERE id=p_id) THEN
UPDATE exams SET name=p_name,isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_exams(character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
