import { useEffect, useState } from "react";
import Box from '@mui/material/Box'
import ReportCard from "../../../components/ReportCard/ReportCard";
import  Button  from "@mui/material/Button";
import GetAppIcon from '@mui/icons-material/GetApp'

export default function Reports({companyId, reportStatus}){
     const [coord,setCoord] = useState( {
      latitude: 0.0,
      longitude: 0.1,
      altitude: 0.0,
      accuracy: 0.2,
      altitudeAccuracy: 0.0,
      heading: 0.0,
      speed: 0.0
    })
    const [reports,setReports] = useState([]);
    console.log(companyId + " " +reportStatus);
    useEffect(() => {
      navigator.geolocation.getCurrentPosition((pos)=>{
        setCoord(pos.coords)
        fetch(`https://localhost:7077/Report/Sort?GeoCoordinate.Latitude=${pos.coords.latitude}&GeoCoordinate.Longitude=${pos.coords.longitude}&GeoCoordinate.Altitude=${pos.coords.altitude || 0}&GeoCoordinate.HorizontalAccuracy=${pos.coords.accuracy || 0}&GeoCoordinate.VerticalAccuracy=${pos.coords.altitudeAccuracy || 0}&GeoCoordinate.Speed=${pos.coords.speed || 0}&GeoCoordinate.Course=${pos.coords.heading || 0}&GeoCoordinate.IsUnknown=true&CompanyId=${companyId}&Status=${ reportStatus || 0}`)
          .then(response => response.json())
          .then(data => setReports(data));
      },(err)=>console.log(err))
      }, []);
    
    return<>
      <Box display={"flex"} flexDirection='column' width={'80%'} gap='1.5rem' paddingTop={'100px'} paddingBottom={'50px'} >
      {reports.map((r)=>{ return <ReportCard coord={coord} report={r} appUserId={companyId} role="Company" onApproveClick={()=> {approve(r) }} onRejectClick={()=>{console.log(r)}}/>})}
      </Box>
    <Box display={'flex'} height={'70%'} alignItems={'flex-start'} >
      <Button onClick={()=>onExportClick(reports)} component="label" variant="contained" startIcon={<GetAppIcon />}>
      Export
    </Button>
    </Box>
    </>
}
function approve(r){
  if((r.reportStatus==2)||(r.reportStatus==4))
  console.log(`https://localhost:7077/Report/UpdateStatus?reportId=${r.reportId}&status=${3}`)
  fetch(`https://localhost:7077/Report/UpdateStatus?reportId=${r.reportId}&status=${3}`, {
          method: 'PUT',
        })
        .then(response => response.json())
        .then(data =>{ 
          console.log( data)
          let transaction ={
            payment:r.awardAmount,
            reportId:r.reportId,
            companyId:r.companyId,
            contractorId:r.contractorId,
          }
          fetch(`https://localhost:7077/Transaction`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(transaction)
        })
        .then(response => response.json())
        .then(data =>{ 
          console.log( data)
          window.location.href = data.result.checkoutUrl
          
        })
        })
        .catch(error => console.error('Error:', error));
}
function onExportClick(reports){
  var dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(reports));
  var downloadAnchorNode = document.createElement('a');
  downloadAnchorNode.setAttribute("href", dataStr);
  downloadAnchorNode.setAttribute("download", "reports" + ".json");
  document.body.appendChild(downloadAnchorNode); 
  downloadAnchorNode.click();
  downloadAnchorNode.remove();
}
