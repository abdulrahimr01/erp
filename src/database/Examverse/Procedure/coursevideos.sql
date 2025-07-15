-- PROCEDURE: public.sp_coursevideos(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_coursevideos(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_coursevideos(
	IN p_title character varying,
	IN p_youtubevideoid character varying,
	IN p_description character varying,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO courseVideos(id,title,youtubevideoid,description,isactive,actionby,actiondate)
VALUES(p_id,p_title,p_youtubevideoid,p_description,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM courseVideos where id=p_id) THEN
UPDATE courseVideos SET title=p_title,youtubevideoid=p_youtubevideoid,description=p.description,
isactive=p.isactive,actionby=p_isactionby,actiondate=p.actiondate WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_coursevideos(character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
