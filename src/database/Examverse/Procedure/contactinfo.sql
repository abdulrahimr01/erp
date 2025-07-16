-- PROCEDURE: public.sp_contactinfo(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_contactinfo(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_contactinfo(
	IN p_name character varying,
	IN p_details character varying,
	IN p_color character varying,
	IN isactive boolean,
	IN actionby character varying,
	IN actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO contactinfo(id,name,details,color,isactive,actionby,actiondate)
VALUES(p_id,p_name,p_details,p_color,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM contactinfo WHERE id=p_id) THEN
UPDATE contactinfo
SET name=p_name,details=details,color=p_color,isactive=p_isactive,actionby=p_isactionby,actiondate=p.actiondate
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_contactinfo(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
