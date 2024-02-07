import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';

export default function EditReportForm() {
  const { id } = useParams();
  const [report, setReport] = useState({});
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');

  useEffect(() => {
    fetch(`https://localhost:7077/Report?id=${id}`)
      .then(response => response.json())
      .then(data => {
        setReport(data);
        setTitle(data.title);
        setDescription(data.description);
      })
      .catch(error => {
        console.error('Error fetching report:', error);
      });
  }, [id]);

  const handleTitleChange = event => {
    setTitle(event.target.value);
  };

  const handleDescriptionChange = event => {
    setDescription(event.target.value);
  };

  const handleFormSubmit = event => {
    event.preventDefault();

    const updatedReport = {
      ...report,
      title: title,
      description: description
    };

    fetch(`https://localhost:7077/Report?id=${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(updatedReport)
    })
      .then(response => {
        if (response.ok) {
          alert('Report updated successfully...');
          window.location.href = "./reports";
          // Navigate back to the reports page
        } else {
          throw new Error('Error updating report.');
        }
      })
      .catch(error => {
        console.error('Error updating report:', error);
        alert(title);
      });
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <TextField
        label="Title"
        value={title}
        onChange={handleTitleChange}
        fullWidth
        required
      />
      <TextField
        label="Description"
        value={description}
        onChange={handleDescriptionChange}
        fullWidth
        required
      />
      <Button type="submit" variant="contained" color="primary">
        Update Report
      </Button>
    </form>
  );
}