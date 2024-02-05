import { useEffect, useState } from "react";
import Box from '@mui/material/Box'
import ReportCard from "../../../components/ReportCard/ReportCard";
import { CleaningServices } from "@mui/icons-material";
export default function Reports(companyId="1", status="0"){
    const [reports,setReports] = useState([]);
    useEffect(() => {
        fetch(`https://localhost:7077/Report/Sort?id=${'ukhui98'}&reportStatus=${''}`)
          .then(response => response.json())
          .then(data => setReports(data));
      }, []);
    
    return<>
    <Box display={"flex"} flexDirection='column' width={'90%'} gap='1.5rem' paddingTop={'100px'} paddingBottom={'50px'} >

    {reports.map((r)=>{return <ReportCard report={r} appUserId={companyId} role="Company" onApproveClick={(e)=>{console.log(e)}} onRejectClick={()=>{console.log(r)}}/>})}
    </Box>
    </>
}