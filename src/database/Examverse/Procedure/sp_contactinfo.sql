-- PROCEDURE: public.sp_contactinfo(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_contactinfo(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_contactinfo(
	IN p_name character varying,
	IN p_details character varying,
	IN p_color character varying,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO contactinfo(name,details,color,isactive,actionby,actiondate)
VALUES(p_name,p_details,p_color,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM contactinfo WHERE id=p_id) THEN
UPDATE contactinfo
SET name=p_name,details=p_details,color=p_color,isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_contactinfo(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
