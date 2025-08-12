-- PROCEDURE: public.sp_papers(character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_papers(character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_papers(
	IN p_exam character varying,
	IN p_name character varying,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--Insert
IF p_id = 0 THEN
INSERT INTO papers(exam, name, isactive, actionby, actiondate) 
VALUES (p_exam, p_name, p_isactive, p_actionby, p_actiondate);
END IF;

--update
IF p_id > 0 AND EXISTS (SELECT 1 FROM papers WHERE id=p_id) THEN
UPDATE papers SET exam = p_exam, name = p_name, isactive = p_isactive, actionby = p_actionby, actiondate = p_actiondate 
WHERE id=p_id;
END IF;

END

$BODY$;
ALTER PROCEDURE public.sp_papers(character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
