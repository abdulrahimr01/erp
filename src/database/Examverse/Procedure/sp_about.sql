-- PROCEDURE: public.sp_about(character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_about(character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_about(
	IN p_type character varying,
	IN p_content character varying,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO public.about(type,content,isactive,actionby,actiondate)
VALUES(p_type,p_content,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM public.about WHERE id=p_id) THEN
UPDATE public.about 
SET type=p_type,content=p_content,isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_about(character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
