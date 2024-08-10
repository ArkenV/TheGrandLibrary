import { fromEvent, interval } from 'rxjs';
import { map, debounceTime, switchMap } from 'rxjs/operators';

// Simulating a search input
const searchInput = document.createElement('input');
document.body.appendChild(searchInput);

// Create an observable from input events
const searchEvents = fromEvent(searchInput, 'input').pipe(
  map((event: InputEvent) => (event.target as HTMLInputElement).value),
  debounceTime(300)  // Wait for 300ms pause in events
);

// Simulating an API call
const searchAPI = (query: string) =>
{
  return interval(1000).pipe(
    map(count => `Result ${count + 1} for "${query}"`)
  );
};

// Combine the input events with the API call
const searchResults = searchEvents.pipe(
  switchMap(query => searchAPI(query))
);

// Subscribe to the results
const subscription = searchResults.subscribe(result =>
{
  console.log(result);
});