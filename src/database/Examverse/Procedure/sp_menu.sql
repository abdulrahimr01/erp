-- PROCEDURE: public.sp_role(character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_role(character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_role(
	IN p_name character varying,
	IN p_notes character varying,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO role(name,notes,isactive,actionby,actiondate)
VALUES(p_name,p_notes,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM role WHERE id=p_id) THEN
UPDATE role 
SET name=p_name,notes=p_notes,isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_role(character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
