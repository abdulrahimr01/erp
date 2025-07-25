-- PROCEDURE: public.sp_coursevideos(character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_coursevideos(character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_coursevideos(
	IN p_coursename character varying,
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
INSERT INTO courseVideos(coursename,title,youtubevideoid,description,isactive,actionby,actiondate)
VALUES(p_coursename,p_title,p_youtubevideoid,p_description,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM courseVideos where id=p_id) THEN
UPDATE courseVideos SET coursename=p_coursename,title=p_title,youtubevideoid=p_youtubevideoid,description=p_description,
isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_coursevideos(character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
