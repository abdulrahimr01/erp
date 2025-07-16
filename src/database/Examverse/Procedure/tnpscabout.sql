-- PROCEDURE: public.sp_tnpscabout(character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_tnpscabout(character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_tnpscabout(
	IN p_text character varying,
	IN isactive boolean,
	IN actionby character varying,
	IN actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO tnpscabout(id,text,isactive,actionby,actiondate)
VALUES(p_id,p_text,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM tnpscabout WHERE id=p_id) THEN
UPDATE tnpscabout 
SET text=p_text,isactive=p_isactive,actionby=p_isactionby,actiondate=p.actiondate
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_tnpscabout(character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
