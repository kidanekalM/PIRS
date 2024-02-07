import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import {Link} from 'react-router-dom';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';


function Copyright(props) {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Copyright © '}
      <Link color="inherit">
        EthioRush
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

// TODO remove, this demo shouldn't need to reset the theme.

const defaultTheme = createTheme();

export default function SignUp() {
    const [title, setTitle] = React.useState('');
    const [description, setDescription] = React.useState('');
    const [userId, setUserId] = React.useState('');
    const [companyId, setCompanyId] = React.useState('');
    const [contractorId, setContractorId] = React.useState('');
    const [locationId, setLocationId] = React.useState('');
    const [altitude, setAltitude] = React.useState('');
    const [course, setCourse] = React.useState('');
    const [horizontalAccuracy, setHorizontalAccuracy] = React.useState('');
    const [verticalAccuracy, setVerticalAccuracy] = React.useState('');
    const [awardAmount, setAwardAmount] = React.useState('');
    // const [selectedDate, setSelectedDate] = useState(new Date());
    const [picture, setPicture] = React.useState(null);
    const [isUnknown, setIsUnknown] = React.useState('');
  
    const handleTitleChange = (event) => {
      setTitle(event.target.value);
    };
  
    const handleDescriptionChange = (event) => {
      setDescription(event.target.value);
    };
  
    const handleUserIdChange = (event) => {
      setUserId(event.target.value);
    };
  
    const handleCompanyIdChange = (event) => {
      setCompanyId(event.target.value);
    };
  
    const handleContractorIdChange = (event) => {
      setContractorId(event.target.value);
    };
  
    const handleLocationIdChange = (event) => {
      setLocationId(event.target.value);
    };
  
    const handleAltitudeChange = (event) => {
      setAltitude(event.target.value);
    };
  
    const handleCourseChange = (event) => {
      setCourse(event.target.value);
    };
  
    const handleHorizontalAccuracyChange = (event) => {
      setHorizontalAccuracy(event.target.value);
    };
  
    const handleVerticalAccuracyChange = (event) => {
      setVerticalAccuracy(event.target.value);
    };
  
    const handleAwardAmountChange = (event) => {
      setAwardAmount(event.target.value);
    };

    const handleDateChange = (date) => {
      setSelectedDate(date);
    };
  
    const handlePictureChange = (event) => {
      // Handle file upload and set the picture state
      const file = event.target.files[0];
      setPicture(file);
    };
  
    const handleIsUnknownChange = (event) => {
      setIsUnknown(event.target.value);
    };
  
    const handleFormSubmit = async (event) => {
      event.preventDefault();
  
      // Create a new FormData object to send the form data
      const formData = new FormData();
      formData.append('title', title);
      formData.append('description', description);
      formData.append('userId', userId);
      formData.append('companyId', companyId);
      formData.append('contractorId', contractorId);
      formData.append('locationId', locationId);
      formData.append('altitude', altitude);
      formData.append('course', course);
      formData.append('horizontalAccuracy', horizontalAccuracy);
      formData.append('verticalAccuracy', verticalAccuracy);
      formData.append('awardAmount', awardAmount);
      // formData.append('date', date);
      // formData.append('picture', picture);
      // formData.append('isUnknown', isUnknown);
  
      // Send the form data to the server
      fetch('https://localhost:7077/Report', {
        method: 'POST',
        body: formData
      }).then((response) => {
        return response.json();
      // }).then((response) =>{
      //   localStorage.setItem("token", response.token);
      //   localStorage.setItem("userId", response.user.id);
      }).then(() => {
        alert("Report Created...");
        window.location.href = "./reports";
      }).catch(() => {
        alert("Invalid input");
      })
    };
  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Create Report
          </Typography>
          <Box component="form" noValidate onSubmit={handleFormSubmit} sx={{ mt: 3 }}>
            <Grid container spacing={2}>
            <Grid item xs={12}>
                <TextField
                  autoComplete="given-name"
                  name="title"
                  required
                  fullWidth
                  id="name"
                  label="Title"
                  autoFocus
                  value={title}
                  onChange={handleTitleChange}
                />
              </Grid>
            <Grid item xs={12}>
                <TextField
                  autoComplete="given-name"
                  name="description"
                  required
                  fullWidth
                  id="name"
                  label="Description"
                  autoFocus
                  value={description}
                  onChange={handleDescriptionChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  autoComplete="given-name"
                  name="name"
                  required
                  fullWidth
                  id="name"
                  label="User Id"
                  autoFocus
                  value={userId}
                  onChange={handleUserIdChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  id="companyid"
                  label="Company Id"
                  name="email"
                  autoComplete="email"
                  value={companyId}
                  onChange={handleCompanyIdChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="contractorId"
                  label="Contractor Id"
                  type="contractorId"
                  id="contractorId"
                  autoComplete="new-contractorId"
                  value={contractorId}
                  onChange={handleContractorIdChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="LocationId"
                  label="Location Id"
                  type="LocationId"
                  id="LocationId"
                  autoComplete="new-LocationId"
                  value={locationId}
                  onChange={handleLocationIdChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="Altitude"
                  label="Altitude"
                  type="Altitude"
                  id="Altitude"
                  autoComplete="new-Altitude"
                  value={altitude}
                  onChange={handleAltitudeChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="Course"
                  label="Course"
                  type="Course"
                  id="Course"
                  autoComplete="new-Course"
                  value={course}
                  onChange={handleCourseChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="HorizontalAccuracy"
                  label="Horizontal Accuracy"
                  type="HorizontalAccuracy"
                  id="HorizontalAccuracy"
                  autoComplete="new-HorizontalAccuracy"
                  value={horizontalAccuracy}
                  onChange={handleHorizontalAccuracyChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="VerticalAccuracy"
                  label="Vertical Accuracy"
                  type="VerticalAccuracy"
                  id="VerticalAccuracy"
                  autoComplete="new-VerticalAccuracy"
                  value={verticalAccuracy}
                  onChange={handleVerticalAccuracyChange}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="AwardAmount"
                  label="Award Amount"
                  type="AwardAmount"
                  id="AwardAmount"
                  autoComplete="new-AwardAmount"
                  value={awardAmount}
                  onChange={handleAwardAmountChange}
                />
              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 1 }}
            >
              Create Report
            </Button>
          </Box>
        </Box>
        <Copyright sx={{ mt: 5 }} />
      </Container>
    </ThemeProvider>
  );
}
