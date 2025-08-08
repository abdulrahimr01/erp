-- PROCEDURE: public.sp_editorials(timestamp without time zone, character varying, character varying, character varying, character varying, timestamp without time zone, timestamp without time zone, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_editorials(timestamp without time zone, character varying, character varying, character varying, character varying, timestamp without time zone, timestamp without time zone, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_editorials(
	IN p_date timestamp without time zone,
	IN p_catagory character varying,
	IN p_title character varying,
	IN p_slug character varying,
	IN p_content character varying,
	IN p_created_at timestamp without time zone,
	IN p_updated_at timestamp without time zone,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO editorials(date,catagory,title,slug,content,created_at,updated_at,isactive,actionby,actiondate)
VALUES(p_date,p_catagory,p_title,p_slug,p_content,p_created_at,p_updated_at,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM editorials WHERE id=p_id) THEN
UPDATE editorials
SET date=p_date,catagory=p_catagory,title=p_title,slug=p_slug,content=p_content,created_at=p_created_at,updated_at=p_updated_at,isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_editorials(timestamp without time zone, character varying, character varying, character varying, character varying, timestamp without time zone, timestamp without time zone, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
