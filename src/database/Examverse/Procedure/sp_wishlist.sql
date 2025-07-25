-- PROCEDURE: public.sp_wishlist(bigint, bigint, character varying, character varying, timestamp without time zone, boolean, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_wishlist(bigint, bigint, character varying, character varying, timestamp without time zone, boolean, bigint);

CREATE OR REPLACE PROCEDURE public.sp_wishlist(
	IN p_userid bigint,
	IN p_itemid bigint,
	IN p_itemtitle character varying,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_isactive boolean,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--Insert
IF p_id = 0 THEN
INSERT INTO wishlist(userid, itemid, itemtitle, actionby, actiondate, isactive) 
VALUES (p_userid, p_itemid, p_itemtitle, p_actionby, p_actiondate, p_isactive);
END IF;

--update
IF p_id > 0 AND EXISTS (SELECT 1 FROM wishlist WHERE id=p_id) THEN
UPDATE wishlist SET userid = p_userid, itemid = p_itemid, itemtitle = p_itemtitle, actionby = p_actionby, actiondate = p_actiondate, isactive = p_isactive 
WHERE id=p_id;
END IF;

END

$BODY$;
ALTER PROCEDURE public.sp_wishlist(bigint, bigint, character varying, character varying, timestamp without time zone, boolean, bigint)
    OWNER TO postgres;
