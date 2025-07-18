-- PROCEDURE: public.sp_defaultpage(character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_defaultpage(character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint);

CREATE OR REPLACE PROCEDURE public.sp_defaultpage(
	IN p_pagename character varying,
	IN p_pagepath character varying,
	IN p_label character varying,
	IN p_icon character varying,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN

--insert
IF p_id=0 THEN
INSERT INTO defaultpage(pagename,pagepath,label,isactive,actionby,actiondate)
VALUES(p_pagename,p_pagepath,p_label,p_isactive,p_actionby,p_actiondate);
END IF;

--update
IF p_id>0 AND EXISTS (SELECT 1 FROM defaultpage WHERE id=p_id) THEN
UPDATE defaultpage 
SET pagename=p_pagename,pagepath=p_pagepath,label=p_label,isactive=p_isactive,actionby=p_actionby,actiondate=p_actiondate
WHERE id=p_id;
END IF;

END
$BODY$;
ALTER PROCEDURE public.sp_defaultpage(character varying, character varying, character varying, character varying, boolean, character varying, timestamp without time zone, bigint)
    OWNER TO postgres;
