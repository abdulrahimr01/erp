-- PROCEDURE: public.sp_currentaffairs(timestamp without time zone, character varying, character varying, character varying, timestamp without time zone, timestamp without time zone, boolean, character varying, timestamp without time zone, character varying, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_currentaffairs(timestamp without time zone, character varying, character varying, character varying, timestamp without time zone, timestamp without time zone, boolean, character varying, timestamp without time zone, character varying, bigint);

CREATE OR REPLACE PROCEDURE public.sp_currentaffairs(
	IN p_date timestamp without time zone,
	IN p_category character varying,
	IN p_slug character varying,
	IN p_content character varying,
	IN p_created_at timestamp without time zone,
	IN p_updated_at timestamp without time zone,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_title character varying,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO currentaffairs(date,category,slug,content,created_at,updated_at,isactive,actionby,actiondate,title)
VALUES(p_date,p_category,p_slug,p_content,p_created_at,p_updated_at,p_isactive,p_actionby,p_actiondate,p_title);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM currentaffairs WHERE id=p_id) THEN
UPDATE currentaffairs
SET date=p_date,category=p_category,slug=p_slug,content=p_content,created_at=p_created_at,updated_at=p_updated_at,isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate,title=p_title
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_currentaffairs(timestamp without time zone, character varying, character varying, character varying, timestamp without time zone, timestamp without time zone, boolean, character varying, timestamp without time zone, character varying, bigint)
    OWNER TO postgres;
